import type { Config } from "drizzle-kit";

export default {
    schema: "./schema/schema.ts",
    out: "./drizzle",
    driver: "mysql2",
    dbCredentials: {
        database: "runshop",
        port: 3306,
        host: "localhost",
        password: "secret123",
        user: "root"
    }
} satisfies Config;