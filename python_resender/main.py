import telebot
import random


file=open("token.txt",'r')
token=file.read().strip()#''
file.close()

file=open("chatId.txt",'r')
chatId=int(file.read().strip())#''
file.close()

bot=telebot.TeleBot(token)
@bot.message_handler(commands=['start'])
def start_message(message):
  bot.send_message(message.chat.id,"Я просто пересылаю сообщение в беседу, не надо в меня писать.")
  bot.send_message(chatId,"Вот в эту беседу я пересылаю")


@bot.message_handler(content_types='text')
def message_reply(message):
    print("msg" + str(message.chat.id))
    # if ("init" in message.text):
    #   try:    bot.send_message(message.chat.id, init() ,reply_to_message_id=message.id)
    #   except Exception as e: print(e)
    #   return
    # if ("d10()" in message.text) or ("d8()" in message.text) or ("d4()" in message.text) or ("d12()" in message.text) or ("d20()" in message.text) or ("d6()" in message.text) or ("d100()" in message.text) or ("dd(" in message.text) or ("dds(" in message.text) :
    #   try:    bot.send_message(message.chat.id,show_result(message.text),reply_to_message_id=message.id)
    #   except Exception as e: print(e)
bot.infinity_polling()


#print(show_result(" sdsdt (2/3)+(3 + (5)+2d20())*7+2**2 hdfhd"))
#print(show_result("d10()"))
#print(show_result("9dd()"))