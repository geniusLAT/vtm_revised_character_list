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


API_URL = 'http://localhost:8080/Dice'

# bot=telebot.TeleBot(token)
# @bot.message_handler(commands=['start'])
# def start_message(message):
#   bot.send_message(message.chat.id,"Я просто пересылаю сообщение в беседу, не надо в меня писать.")
#   bot.send_message(chatId,"Вот в эту беседу я пересылаю")


# @bot.message_handler(content_types='text')
# def message_reply(message):
#     print("msg" + str(message.chat.id))

# bot.infinity_polling()


urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)


bot = telebot.TeleBot(TOKEN)


def poll_api_and_send():
  """Фоновая функция: забирает элементы из очереди и отправляет только если value != null."""
  while True:
    try:
      response = requests.get(API_URL, verify=False, timeout=3)

      if response.status_code == 200 and response.text.strip():
        data = response.json()

        # Достаем содержимое ключа "value"
        value = data.get('value')

        # Если value равен None (в JSON это null), значит очередь пуста
        if value is not None:
          # Теперь данные кубиков лежат внутри объекта value
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
  # Запускаем фоновый поток (daemon=True завершит поток при остановке бота)
  api_thread = threading.Thread(target=poll_api_and_send, daemon=True)
  api_thread.start()

  # Запускаем лонг-поллинг бота
  bot.infinity_polling()