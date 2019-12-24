﻿using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Bot.Handlers
{
    /// <summary>
    /// Put your subscriptions to events here!
    /// Just one non awaited async Method per functionality you want to provide
    /// </summary>
    public class EventHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly Config _config;
        private readonly LogHandler _logger;

        public SocketTextChannel LogChannel
        {
            get
            {
                var guild = _client.GetGuild(446832659377946625);
                var channel = guild.GetTextChannel(Convert.ToUInt64(_config.LogChannelID));
                return channel;
            }
        }

        public EventHandler(DiscordSocketClient client, LogHandler logger)
        {
            // Set everything we need from DI
            _client = client;
            _config ??= new ConfigHandler().GetConfig();
            _logger = logger;
        }

        public void InitializeEvents()
        {
            // Create WebSocket-based command context based on message
            _client.ChannelCreated += ChannelCreated;
            _client.ChannelDestroyed += ChannelDestroyed;
            _client.ChannelUpdated += ChannelUpdated;
            _client.Connected += Connected;
            _client.CurrentUserUpdated += CurrentUserUpdated;
            _client.Disconnected += Disconnected;
            _client.GuildAvailable += GuildAvailable;
            _client.GuildMembersDownloaded += GuildMembersDownloaded;
            _client.GuildMemberUpdated += GuildMemberUpdated;
            _client.GuildUnavailable += GuildUnavailable;
            _client.GuildUpdated += GuildUpdated;
            _client.JoinedGuild += JoinedGuild;
            _client.LatencyUpdated += LatencyUpdated;
            _client.LeftGuild += LeftGuild;
            _client.Log += Log;
            _client.LoggedIn += LoggedIn;
            _client.LoggedOut += LoggedOut;
            _client.MessageDeleted += MessageDeleted;
            _client.MessageReceived += MessageReceived;
            _client.MessageUpdated += MessageUpdated;
            _client.ReactionAdded += ReactionAdded;
            _client.ReactionRemoved += ReactionRemoved;
            _client.ReactionsCleared += ReactionsCleared;
            _client.Ready += Ready;
            _client.RecipientAdded += RecipientAdded;
            _client.RecipientRemoved += RecipientRemoved;
            _client.RoleCreated += RoleCreated;
            _client.RoleDeleted += RoleDeleted;
            _client.RoleUpdated += RoleUpdated;
            _client.UserBanned += UserBanned;
            _client.UserIsTyping += UserIsTyping;
            _client.UserJoined += UserJoined;
            _client.UserLeft += UserLeft;
            _client.UserUnbanned += UserUnbanned;
            _client.UserUpdated += UserUpdated;
            _client.UserVoiceStateUpdated += UserVoiceStateUpdated;
        }

        private async Task ChannelCreated(SocketChannel channel)
        {
            // await LogChannel.SendMessageAsync(embed: EmbedHandler.Neutral(message));

            await LogChannel.SendMessageAsync($"Channel {channel} created");
            _logger.Info($"Channel {channel} created");
        }

        private async Task ChannelDestroyed(SocketChannel channel)
        {
            _logger.Info($"Channel {channel} destroyed");
        }

        private async Task ChannelUpdated(SocketChannel channelBefore, SocketChannel channelAfter)
        {
        }

        private async Task Connected()
        {
        }

        private async Task CurrentUserUpdated(SocketSelfUser userBefore, SocketSelfUser userAfter)
        {
        }

        private async Task Disconnected(Exception exception)
        {
        }

        private async Task GuildAvailable(SocketGuild guild)
        {
        }

        private async Task GuildMembersDownloaded(SocketGuild guild)
        {
        }

        private async Task GuildMemberUpdated(SocketGuildUser userBefore, SocketGuildUser userAfter)
        {
            // Console.WriteLine(userAfter);
            //
            // await LogChannel.SendMessageAsync(embed: EmbedHandler.LogUserRole(userBefore, userAfter));
            // await LogChannel.SendMessageAsync($"Channel {channel} created");
            // _logger.Info($"Channel {channel} created");
        }

        private async Task GuildUnavailable(SocketGuild guild)
        {
        }

        private async Task GuildUpdated(SocketGuild guildBefore, SocketGuild guildAfter)
        {
        }

        private async Task JoinedGuild(SocketGuild guild)
        {
        }

        private async Task LatencyUpdated(int latencyBefore, int latencyAfter)
        {
        }

        private async Task LeftGuild(SocketGuild guild)
        {
        }

        private async Task Log(LogMessage logMessage)
        {
        }

        private async Task LoggedIn()
        {
        }

        private async Task LoggedOut()
        {
        }

        private async Task MessageDeleted(Cacheable<IMessage, ulong> cacheMessage, ISocketMessageChannel channel)
        {
        }

        private async Task MessageReceived(SocketMessage message)
        {
        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> cacheMessageBefore, SocketMessage messageAfter, ISocketMessageChannel channel)
        {
        }

        private async Task ReactionAdded(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel, SocketReaction reaction)
        {
        }

        private async Task ReactionRemoved(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel, SocketReaction reaction)
        {
        }

        private async Task ReactionsCleared(Cacheable<IUserMessage, ulong> cacheMessage, ISocketMessageChannel channel)
        {
        }

        private async Task Ready()
        {
        }

        private async Task RecipientAdded(SocketGroupUser user)
        {
        }

        private async Task RecipientRemoved(SocketGroupUser user)
        {
        }

        private async Task RoleCreated(SocketRole role)
        {
        }

        private async Task RoleDeleted(SocketRole role)
        {
        }

        private async Task RoleUpdated(SocketRole roleBefore, SocketRole roleAfter)
        {
        }

        private async Task UserBanned(SocketUser user, SocketGuild guild)
        {
        }

        private async Task UserIsTyping(SocketUser user, ISocketMessageChannel channel)
        {
        }

        private async Task UserJoined(SocketGuildUser user)
        {
        }

        private async Task UserLeft(SocketGuildUser user)
        {
        }

        private async Task UserUnbanned(SocketUser user, SocketGuild guild)
        {
        }

        private async Task UserUpdated(SocketUser oldUser, SocketUser newUser)
        {
            var message = "Username Changed";
            await LogChannel.SendMessageAsync(embed: EmbedHandler.Update(message, oldUser, newUser));
            _logger.Update($"[{message}] {oldUser} => {newUser}");

        }

        private async Task UserVoiceStateUpdated(SocketUser user, SocketVoiceState voiceStateBefore, SocketVoiceState voiceStateAfter)
        {
        }
    }
}