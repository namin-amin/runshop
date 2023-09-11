import type { InferInsertModel, InferSelectModel } from "drizzle-orm";
import { serial, text, timestamp, mysqlTable } from 'drizzle-orm/mysql-core';

export const user = mysqlTable("users", {
    id: serial("id"),
    name: text("name"),
    email: text("email"),
    password: text("password"),
    role: text("role").$type<"admin" | "customer">(),
    createdAt: timestamp("created_at"),
    updatedAt: timestamp("updated_at"),
});

export type user_type = InferSelectModel<typeof user>;
export type user_insert_type = InferInsertModel<typeof user>;