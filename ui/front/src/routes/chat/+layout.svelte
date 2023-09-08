<script lang="ts">
    import ChatTopBar from "../../components/chat/ChatTopBar.svelte";
    import ChatListContainer from "../../components/chat/chatlist/ChatListContainer.svelte";
    import WindowHeader from "../../components/chat/chatwindow/WindowHeader.svelte";
    import Editor from "../../components/chat/editor/Editor.svelte";
    import WindowSubHeader from "../../components/chat/chatwindow/WindowSubHeader.svelte";
</script>

<div class="w-screen h-screen overflow-hidden grid grid-cols-21 grid-rows-16">
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
        class="col-start-2 col-span-4 bg-blend-darken bg-accent border-t border-accent row-start-2 row-span-full overscroll-auto"
    >
        <ChatListContainer />
    </div>
    <div class="col-start-6 col-span-full row-start-2 row-end-[12]">
        <WindowHeader />
        <WindowSubHeader />
        <div class="w-full h-full p-2">
            <slot />
        </div>
    </div>
    <div
        class="col-start-6 col-span-full mx-3 row-start-[15] row-span-1 justify-center flex items-center"
    >
        <Editor />
    </div>
</div>
