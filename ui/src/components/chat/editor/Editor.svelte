<script>
    import AttachementsAndExtra from "./AttachementsAndExtra.svelte";
    import Container from "./Container.svelte";
    import TextDecoration from "./TextDecoration.svelte";
    let txtvalue = "";
    $: cansend = () => {
        return txtvalue !== "";
    };
</script>

<Container>
    <div>
        <TextDecoration />
    </div>
    <textarea
        bind:value={txtvalue}
        class="textarea resize-none outline-none focus:outline-none no-scrollbar"
    />
    <div class="w-full justify-self-end">
        <AttachementsAndExtra send={cansend()} />
    </div>
</Container>
