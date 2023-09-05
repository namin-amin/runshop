<script lang="ts">
    import ChatTopBar from "../../components/chat/ChatTopBar.svelte";
    import ChatListContainer from "../../components/chat/chatlist/ChatListContainer.svelte";
</script>

<div class="w-screen h-screen overflow-hidden grid grid-cols-22 grid-rows-16">
    <div
        class="col-span-full shadow-md z-50 flex w-full justify-end
        items-center border-b border-neutral-500 border-opacity-80"
    >
        <ChatTopBar />
    </div>
    <div
        class=" col-start-1 col-span-1 h-full bg-accent border-r border-neutral-500 row-start-2 row-span-full"
    />
    <div
        class="col-start-2 col-span-5 bg-blend-darken bg-accent border-t border-accent row-start-2 row-span-full overscroll-auto"
    >
        <ChatListContainer />
    </div>
    <slot />
</div>
