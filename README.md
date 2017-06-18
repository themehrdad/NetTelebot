# NetTelebot

<a href="https://teamcity.nesterov.tk/viewType.html?buildTypeId=NetTelebotGithubRepository_BuildTestDebug&guest=1">
<img src="https://teamcity.nesterov.tk/app/rest/builds/buildType:(id:NetTelebotGithubRepository_BuildTestDebug)/statusIcon"/>
</a>

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/d1d114894a7345999ecff230bdbd9bdb)](https://www.codacy.com/app/vertigra/NetTelebot-2.0?utm_source=github.com&utm_medium=referral&utm_content=vertigra/NetTelebot-2.0&utm_campaign=badger)

Telegram bot API implementation on .NET framework

# About
Do you want to create a smart automated bot on Telegram App? If you plan to write the logic using .NET framework, this tool might help you.

To support devices with Windows XP, the library version is developed under the .NET Framework 4

# Usage
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

# Documentation

Look at the [Wiki](https://github.com/themehrdad/NetTelebot/wiki/Documentation)
