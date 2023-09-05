<script lang="ts">
    import { twMerge } from "tw-merge";
    export let online = false;
    export let name = "";
    export let imgUrl =
        "https://media.licdn.com/dms/image/C5603AQGlEmco79zJLQ/profile-displayphoto-shrink_800_800/0/1635673979105?e=1699488000&v=beta&t=amSEer4E0z-szwCwSN7UJrpJL4OGs7RJwS7N-8h-XeU";
    export let showName = false;
    export let className = "";
</script>

<div class="w-full h-12 m-2 gap-2 flex items-center text-neutral-300">
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
