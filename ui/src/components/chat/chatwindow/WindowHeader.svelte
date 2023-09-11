<script lang="ts">
    import DownArrow from "../../icons/DownArrow.svelte";
    import type { WindowHeaderProps } from "./prop_types";

    export let props: WindowHeaderProps = {
        title: "Heading",
        description: "SomeDecription dfhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhdyyyyyy",
    };
</script>

<div
    class="h-12 border-1 border-b-neutral-300 w-full items-center flex px-4 justify-between"
>
    <div class="flex justify-center items-center gap-4">
        <h1 class="text-2xl font-bold">{props.title}</h1>
        <DownArrow />
        <p
            class="ml-8 text-sm text-neutral-500 whitespace-nowrap text-ellipsis w-96 overflow-hidden"
        >
            {props.description}
        </p>
    </div>

    <div class=" justify-self-end">
        <h1 class="justify-self-center">last row</h1>
    </div>
</div>
