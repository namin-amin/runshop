<script lang="ts">
    import Avatar from "../chatlist/Avatar.svelte";
    import type { ChatThreadProps } from "./prop_types";

    export let props: ChatThreadProps = {
        avatarUrl: "",
        chat: "akakaka",
        chatTime: new Date(),
        name: "Namin",
    };
</script>

<div
    class="w-full h-28 my-1 bg-neutral-100 rounded-md p-1 justify-start items-start flex"
>
    <Avatar className="w-10 h-10" />
    <h1>{props.chat}</h1>
    <h1>{props.name}</h1>
</div>
