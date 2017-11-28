<img src="Images/Logo/logo-100.png"  alt="logo" title="NetTelebot" align="right" height="60" />

# NetTelebot [![StackShare](https://img.shields.io/badge/tech-stack-0690fa.svg?style=flat)](https://stackshare.io/vertigra/nettelebot) [![NuGet version](https://badge.fury.io/nu/nettelebot.svg)](https://badge.fury.io/nu/nettelebot) [![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/themehrdad/NetTelebot/blob/master/LICENSE)

Telegram bot API implementation on .NET framework

| Repository | [Net-Telebot-2.0](https://github.com/vertigra/NetTelebot-2.0) (master) | [Net-Telebot](https://github.com/themehrdad/NetTelebot) (master) |
| --- | --- | --- |
| **Build** |<a href="https://teamcity.nesterov.tk/viewType.html?buildTypeId=NetTelebotDevel&guest=1"><img src="https://teamcity.nesterov.tk/app/rest/builds/buildType:(id:NetTelebotDevel)/statusIcon"> [![Build status](https://ci.appveyor.com/api/projects/status/xrdhuq2v0piigwfq?svg=true)](https://ci.appveyor.com/project/vertigra/nettelebot-2-0) | [![Build status](https://ci.appveyor.com/api/projects/status/1be8bona8ow83whb/branch/master?svg=true)](https://ci.appveyor.com/project/vertigra/nettelebot/branch/master) |
| **Coverage** | [![Coverage Status](https://coveralls.io/repos/github/vertigra/NetTelebot-2.0/badge.svg)](https://coveralls.io/github/vertigra/NetTelebot-2.0) | [![Coverage Status](https://coveralls.io/repos/github/themehrdad/NetTelebot/badge.svg)](https://coveralls.io/github/themehrdad/NetTelebot) |
| **Quality** | [![Codacy Badge](https://api.codacy.com/project/badge/Grade/d1d114894a7345999ecff230bdbd9bdb)](https://www.codacy.com/app/vertigra/NetTelebot-2.0?utm_source=github.com&utm_medium=referral&utm_content=vertigra/NetTelebot-2.0&utm_campaign=badger) [![BCH compliance](https://bettercodehub.com/edge/badge/vertigra/NetTelebot-2.0?branch=master)](https://bettercodehub.com/) | [![Codacy Badge](https://api.codacy.com/project/badge/Grade/275548e27e784897ab704a7349ed6b37)](https://www.codacy.com/app/vertigra/NetTelebot?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=themehrdad/NetTelebot&amp;utm_campaign=Badge_Grade) [![BCH compliance](https://bettercodehub.com/edge/badge/themehrdad/NetTelebot?branch=master)](https://bettercodehub.com/) | 

**Net-Telebot-2.0** is development repository.  
**Net-Telebot** is release repository.  
More about this on the wiki page [stages of development](https://github.com/themehrdad/NetTelebot/wiki/Stages-of-development)

## About
Do you want to create a smart automated bot on Telegram App? If you plan to write the logic using .NET framework, this tool might help you.

To support devices with Windows XP, the library version is developed under the .NET Framework 4

## Usage
After creating your own bot on [Telegram](https://core.telegram.org/bots/), you need to add a reference to "nettelebot" library.

All you need to do is to create an instance of TelegramBotClient class.

```C#
var botClient = new TelegramBotClient() { Token = "[YOUR_BOT_TOKEN]" };
```

Now you may send messages or even photos using methods in this class:

```C#
botClient.SendMessage(Chat_Id, "Hello!");
```

Or even you may listen for incoming messages from uses:

```C#
botClient.UpdatesReceived += botClient_UpdatesReceived;
private void botClient_UpdatesReceived(object sender, TelegramUpdateEventArgs e)
{
   var botClient = (TelegramBotClient)sender;
   foreach (var item in e.Updates)
   {
     if (item.Message.Text != null)
       tbc.SendMessage(item.Message.Chat.Id, item.Message.Text);
   }
}
```

See more examples in the project [wiki](https://github.com/themehrdad/NetTelebot/wiki)

## Plans

On the nearest release (1.0.13)
- [x] Remove obsolete methods 
- [ ] Add all sticker methods and types
- [ ] Add new method sendMediaGroup and two kinds of InputMedia objects to support the new albums feature
- [ ] Add support for pinning messages in channels. pinChatMessage and unpinChatMessage accept channels
- [ ] Add the new field provider_data to sendInvoice for sharing information about the invoice with the payment provider


For the project
- [ ] Full support API Telegrams

More details [here](https://github.com/vertigra/NetTelebot-2.0/projects/1)

## Thanks

The logo is provided by the site [icons8.com](https://icons8.com/)

