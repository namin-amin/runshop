<script>
    import PlusLarge from "../../icons/PlusLarge.svelte";
    import Avatar from "./Avatar.svelte";
    import GroupContainer from "./GroupContainer.svelte";
</script>

<div
    class=" w-full h-full flex flex-col gap-1 max-h-screen overflow-y-auto overflow-x-hidden no-scrollbar"
>
    <div class="flex gap-4 justify-around items-center text-neutral-200 m-2">
        <h1 class="text-3xl justify-self-start">Workspaces</h1>
        <PlusLarge />
    </div>
    <hr />
    <GroupContainer>
        <h1>Yo</h1>
    </GroupContainer>

    <GroupContainer>
        <h1>Yo</h1>
    </GroupContainer>

    <GroupContainer>
        <h1>Yo</h1>
    </GroupContainer>

    <GroupContainer>
        <h1>Yo</h1>
    </GroupContainer>
</div>
