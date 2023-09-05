<script lang="ts">
    import Search from "../icons/Search.svelte";
    export let typing = false;
    export let searchBoxValue = "";

    function showPlaceHolder() {
        if (searchBoxValue === "") {
            typing = !typing;
        }
    }
</script>

<div
    class="w-1/2 h-4/6 rounded-lg
        backdrop-blur-lg backdrop-brightness-90
        backdrop-contrast-75 flex flex-row
        items-center justify-center
        shadow-md
        "
>
    {#if !typing}
        <div
            class="text-base-300 gap-2 flex flex-row justify-center items-center absolute"
        >
            <Search />
            <p>Search</p>
        </div>
    {/if}
    <input
        type="text"
        class="input bg-transparent w-full h-full outline-none ml-2 text-white z-50 text-center"
        on:focus={() => showPlaceHolder()}
        on:focusout={() => showPlaceHolder()}
        bind:value={searchBoxValue}
    />
</div>
