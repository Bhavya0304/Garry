const { ActivityHandler } = require('botbuilder');

class GarryBot extends ActivityHandler {
    constructor() {
        super();

        this.onMessage(async (context, next) => {
            const userMessage = context.activity.text;
            console.log(`📨 Message received: ${userMessage}`);

            await context.sendActivity(`👋 Hi! You said: "${userMessage}"`);

            await next();
        });

        this.onMembersAdded(async (context, next) => {
            const membersAdded = context.activity.membersAdded;
            for (let member of membersAdded) {
                if (member.id !== context.activity.recipient.id) {
                    await context.sendActivity('👋 Hello! I am Garry, your meeting assistant.');
                }
            }

            await next();
        });
    }
}

module.exports = { GarryBot };
