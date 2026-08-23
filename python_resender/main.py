import telebot
import random
import threading
import time
import urllib3
import requests

print("VTM bot activated")

file=open("token.txt",'r')
TOKEN=file.read().strip()#''
file.close()

file=open("chatId.txt",'r')
CHAT_ID=int(file.read().strip())#''
file.close()

file=open("hiddenChatId.txt",'r')
HIDDEN_CHAT_ID=int(file.read().strip())#''
file.close()

BASE_API_URL = 'http://localhost:5000'

API_URL_DICE = BASE_API_URL + "/Dice"
API_URL_MESSAGE = BASE_API_URL + "/Message"


urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


bot = telebot.TeleBot(TOKEN)


def poll_dice_api_and_send():
  """Фоновая функция: забирает элементы из очереди и отправляет только если value != null."""
  while True:
    try:
      response = requests.get(API_URL_DICE, verify=False, timeout=3)

      if response.status_code == 200 and response.text.strip():
        data = response.json()

        value = data.get('value')

        if value is not None:
          comment = value.get('comment', 'Без комментария')

          roll_res = value.get('rollResult') or {}
          rolls = roll_res.get('rolls', [])
          successes = roll_res.get('succeses', 0)
          is_crit_fail = roll_res.get('criticallyFailed', False)

          msg_text = comment
          for roll in rolls:
            msg_text += str(roll) + " "
          msg_text += "\nУспехов: " +str(successes)

          if (is_crit_fail):
            msg_text += "\nКритический провал"
          

          bot.send_message(CHAT_ID, msg_text, parse_mode='Markdown')

    except Exception as e:
      print(f'Ошибка при запросе к API: {e}')

    time.sleep(1)

def poll_message_api_and_send():
  """Фоновая функция: забирает элементы из очереди и отправляет только если value != null."""
  while True:
    try:
      response = requests.get(API_URL_MESSAGE, verify=False, timeout=3)

      if response.status_code == 200 and response.text.strip():
        data = response.json()

        value = data.get('value')

        if value is not None:
          msg_text = value.get('text')
          print(msg_text)
          hidden = value.get('hidden')
          chat_id = CHAT_ID
          if hidden:
            chat_id = HIDDEN_CHAT_ID
          bot.send_message(chat_id, msg_text, parse_mode='Markdown')

    except Exception as e:
      print(f'Ошибка при запросе к API: {e}')

    time.sleep(1)


@bot.message_handler(commands=['start'])
def start_message(message):
  bot.send_message(
      message.chat.id,
      'Я просто пересылаю сообщения в беседу, не надо в меня писать.',
  )


@bot.message_handler(content_types=['text'])
def message_reply(message):
  print(f'msg chat id: {message.chat.id}')


if __name__ == '__main__':
  dice_api_thread = threading.Thread(target=poll_dice_api_and_send, daemon=True)
  dice_api_thread.start()

  message_api_thread = threading.Thread(target=poll_message_api_and_send, daemon=True)
  message_api_thread.start()

  # Запускаем лонг-поллинг бота
  bot.infinity_polling()