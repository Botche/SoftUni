module.exports = {
    development: {
        port: process.env.PORT || 3000,
        databaseUrl: `mongodb+srv://user:${process.env.DB_PASSWORD}@cluster0-neyyd.mongodb.net/cubicle-db?retryWrites=true&w=majority`
    },
    production: {}
};