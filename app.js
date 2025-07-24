require('dotenv').config();
const restify = require('restify');
const { BotFrameworkAdapter } = require('botbuilder');
const { GarryBot } = require('./bots/garry-bot');

// Create server
const server = restify.createServer();
server.listen(process.env.Port || 3978, () => {
    console.log(`🚀 Bot is listening on http://localhost:${server.address().port}`);
});

// Create adapter
const adapter = new BotFrameworkAdapter({
    appId: process.env.MicrosoftAppId,
    appPassword: process.env.MicrosoftAppPassword
});

// Handle errors
adapter.onTurnError = async (context, error) => {
    console.error('❌ [onTurnError]', error);
    await context.sendActivity('Oops. Something went wrong!');
};

// Create bot
const bot = new GarryBot();

// Message endpoint
server.post('/api/messages', async (req, res) => {
    await adapter.processActivity(req, res, async (context) => {
        await bot.run(context);
    });
});
