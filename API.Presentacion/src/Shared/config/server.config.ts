
export interface ServerConfig {
    port: number
}

export default () => ({
    server: {
        port: parseInt(process.env.SERVER_PORT, 10),
    }
});