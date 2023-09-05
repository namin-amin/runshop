<script>
    import Avatar from "./Avatar.svelte";
    import GroupContainer from "./GroupContainer.svelte";
</script>

<div
    class=" w-full h-full flex flex-col gap-1 max-h-screen overflow-y-auto overflow-x-hidden no-scrollbar"
>
    <div>
        <Avatar showName online className="w-14" />
    </div>
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
