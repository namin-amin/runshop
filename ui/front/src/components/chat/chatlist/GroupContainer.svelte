<script lang="ts">
    import { fade, slide } from "svelte/transition";
    import RightArrow from "../../icons/RightArrow.svelte";
    import DownArrow from "../../icons/DownArrow.svelte";

    let expand = false;

    function toggleExpanf() {
        expand = !expand;
    }

    export let header = "Hello";
</script>

<div class="text-neutral-200 max-h-[60%] w-full m-1 flex flex-col">
    <div class="flex flex-row justify-stretch items-center">
        {#if expand}
            <DownArrow on:click={toggleExpanf} on:keydow={toggleExpanf} />
        {:else}
            <RightArrow on:click={toggleExpanf} on:keydown={toggleExpanf} />
        {/if}
        <h1 class="flex-1 text-2xl ml-4">{header}</h1>
    </div>

    {#if expand}
        <div class="p-2 h-full w-full overflow-y-auto no-scrollbar" in:fade>
            <slot />
        </div>
    {/if}
</div>
