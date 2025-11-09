# Changelog

All notable changes to NetTelebot will be documented in this file.

## [1.1.0] - 2025-01-09

This release brings NetTelebot up to date with modern Telegram Bot API features, adding support for many methods and types that have been introduced since version 1.0.12.

### Added

#### New Methods
- **`SendAnimation()`** - Send animation files (GIF or H.264/MPEG-4 AVC video without sound)
- **`SendDice()`** - Send animated emoji that displays a random value (🎲, 🎯, 🏀, ⚽, 🎳, 🎰)
- **`SendPoll()`** - Send native polls with support for quiz mode, multiple answers, and explanations
- **`StopPoll()`** - Stop a poll that was sent by the bot
- **`CopyMessage()`** - Copy messages of any kind between chats
- **`SendMediaGroup()`** - Send a group of photos, videos, documents or audios as an album (2-10 items)
- **`PinChatMessage()`** - Pin messages in chats and channels
- **`UnpinChatMessage()`** - Unpin messages in chats and channels
- **`AnswerCallbackQuery()`** - Correctly spelled version of the callback query answer method

#### New Types

**Media Types:**
- `AnimationInfo` - Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound)
- `DiceInfo` - Represents an animated emoji with a random value
- `PollInfo` - Information about a poll (regular or quiz mode)
- `PollOptionInfo` - Individual poll option with vote count

**Input Media Types (for sendMediaGroup):**
- `InputMedia` - Base class for media to be sent
- `InputMediaPhoto` - Photo to be sent as part of a media group
- `InputMediaVideo` - Video to be sent as part of a media group
- `InputMediaAnimation` - Animation to be sent as part of a media group
- `InputMediaAudio` - Audio file to be sent as part of a media group
- `InputMediaDocument` - Document to be sent as part of a media group

**Helper Types:**
- `LinkPreviewOptions` - Options for link preview generation
- `ReplyParameters` - Parameters for message replies with support for quotes

#### New Fields

**UserInfo:**
- `IsPremium` - True if user is a Telegram Premium subscriber
- `AddedToAttachmentMenu` - True if user added the bot to attachment menu
- `CanJoinGroups` - True if bot can be invited to groups (returned in getMe)
- `CanReadAllGroupMessages` - True if privacy mode is disabled (returned in getMe)
- `SupportsInlineQueries` - True if bot supports inline queries (returned in getMe)
- `CanConnectToBusiness` - True if bot can be connected to Telegram Business
- `HasMainWebApp` - True if bot has a main Web App
- **Breaking Change:** `Id` type changed from `int` to `long` for larger user IDs

**ChatInfo:**
- `IsForum` - True if supergroup is a forum with topics enabled
- `EmojiStatusCustomEmojiId` - Custom emoji identifier for emoji status
- `HasPrivateForwards` - Privacy setting for forwarding user messages
- `HasRestrictedVoiceAndVideoMessages` - Privacy setting for voice/video messages
- `JoinToSendMessages` - True if users need to join before sending messages
- `JoinByRequest` - True if join requests need admin approval

**MessageInfo:**
- `Animation` - Information about animation in the message
- `Dice` - Information about dice in the message
- `Poll` - Information about poll in the message

### Fixed
- **Method name typo:** `AswerCallbackQuery` is now deprecated in favor of the correctly spelled `AnswerCallbackQuery`
  - The old method is marked with `[Obsolete]` attribute and redirects to the new method
  - Maintains backward compatibility for existing code

### Changed
- Updated copyright year to 2017-2025
- Version bumped from 1.0.12.0 to 1.1.0.0
- User IDs now use `long` type instead of `int` to support larger ID values

### Implementation Notes

**Media Groups:**
- `SendMediaGroup()` supports sending 2-10 media items as an album
- Supports photos, videos, documents, audios, and animations
- Each media item can have its own caption and parse mode

**Polls:**
- Regular polls support multiple answers
- Quiz mode supports correct answer indication and explanations
- Polls can be scheduled to close automatically or closed immediately

**Backward Compatibility:**
- Old `AswerCallbackQuery` method still works but shows obsolete warning
- All existing methods and types remain unchanged
- New fields in existing types are optional and won't break existing code

### Migration Guide

If you're upgrading from 1.0.12:

1. **User IDs:** If you're storing user IDs in a database, ensure the column type can handle `long` values
2. **Callback Queries:** Consider updating `AswerCallbackQuery()` calls to `AnswerCallbackQuery()` to remove obsolete warnings
3. **New Features:** Review the new methods and types to enhance your bot's capabilities

### What's Next

Future releases will focus on:
- Remaining Bot API features (Reactions, Stories, Business Accounts)
- WebApp support
- Inline mode enhancements
- Forum topic management
- Additional sticker methods
- Payment improvements

---

## [1.0.12] - 2017

Previous stable release. See git history for details.
