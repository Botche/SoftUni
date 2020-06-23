module.exports = {
    development: {
        port: process.env.PORT,
        databaseUrl: process.env.DB_CONNECTION_STRING,
        privateKey: process.env.JWT_PRIVATE_KEY,
    },
    production: {}
};