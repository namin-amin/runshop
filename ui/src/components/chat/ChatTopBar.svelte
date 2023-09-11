<script lang="ts">
    import LeftPointArrow from "../icons/LeftPointArrow.svelte";
    import RightPointArrow from "../icons/RightPointArrow.svelte";
    import TopBarSearch from "./TopBarSearch.svelte";
    import Avatar from "./chatlist/Avatar.svelte";
</script>

<div class="h-full w-full bg-accent flex items-center">
    <div
        class="flex items-center gap-4 justify-center pl-20 w-fit flex-1 h-full text-neutral-200"
    >
        <LeftPointArrow />
        <RightPointArrow />
        <TopBarSearch />
    </div>
    <div class="justify-self-end m-3 p-3">
        <Avatar className="w-10" online />
    </div>
</div>
