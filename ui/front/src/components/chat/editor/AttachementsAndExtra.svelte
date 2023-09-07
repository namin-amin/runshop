<script>
    import Mic from "../../icons/Mic.svelte";
    import PlusLarge from "../../icons/PlusLarge.svelte";
    import Send from "../../icons/Send.svelte";
    import Smilyemoji from "../../icons/Smilyemoji.svelte";
    import VideoCamera from "../../icons/VideoCamera.svelte";

    export let send = false;
    $: btnCls = () => {
        if (send) {
            return "bg-success w-24 gap-2 p-3 h-full justify-self-end flex flex-row justify-center items-center rounded-xl cursor-pointer hover:bg-neutral-300 active:bg-success-focus transition-all text-neutral-200";
        }
        return "bg-neutral-200 w-24 gap-2 p-3 h-full justify-self-end flex flex-row justify-center items-center rounded-xl cursor-pointer hover:bg-neutral-300 active:bg-neutral-200 transition-all";
    };
</script>

<div
    class="w-full h-8 px-2 mb-1 flex gap-4 items-center container justify-between"
>
    <div class="flex items-center justify-start gap-4">
        <div
            class="p-1 bg-neutral-300 flex justify-center items-center rounded-full cursor-pointer hover:bg-neutral-400 transition-all"
        >
            <PlusLarge className="" />
        </div>
        <Smilyemoji />
        <VideoCamera />
        <Mic />
    </div>
    <div class={btnCls()}>
        <h1>Send</h1>
        <Send />
    </div>
</div>
