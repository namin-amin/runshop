import { user, type user_insert_type } from './../../../../schema/schema';
import { db } from "$lib/server/db";
import type { RequestHandler } from './$types';
import { json } from "@sveltejs/kit";

export const GET: RequestHandler = async () => {
    const users = await db.select().from(user);
    return json(users, {
        status: 201
    });
};

export const POST: RequestHandler = async ({ request }) => {
    console.log("request added");

    const data: user_insert_type = await request.json();
    console.log(data);

    const newdata = await db.insert(user).values(data);
    console.log(newdata);

    return new Response(undefined, {
        status: 202,
        statusText: "inserted"
    });
};