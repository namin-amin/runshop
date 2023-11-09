<script lang="ts">
    import { twMerge } from "tw-merge";
    export let online = false;
    export let name = "";
    export let imgUrl =
        "/profile.jpg";
    export let showName = false;
    export let className = "";
</script>

<div
    class="w-12 h-12 m-2 gap-2 flex items-center text-neutral-300 cursor-pointer"
>
    <div class="avatar" class:online>
        {#if imgUrl != ""}
            <div class={` rounded-full ${className}`}>
                <img src={imgUrl} alt="logo" />
            </div>
        {:else}
            <div
                class={`bg-neutral-focus text-neutral-content rounded-full  ${className}`}
            >
                <span class="text-3xl">{name.at(0)?.toUpperCase()}</span>
            </div>
        {/if}
    </div>
    {#if showName}
        <h1 class="text-2xl">Namin Amin</h1>
    {/if}
</div>
