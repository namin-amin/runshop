<script lang="ts">
    import { slide } from "svelte/transition";
    export let className = "h-5 w-5 stroke-2 cursor-pointer ";
</script>

<svg
    xmlns="http://www.w3.org/2000/svg"
    width="16"
    height="16"
    fill="currentColor"
    class={`bi bi-chevron-down ${className}`}
    viewBox="0 0 16 16"
    in:slide={{ delay: 100, duration: 100 }}
    on:click
    on:keydown
    role="none"
>
    <path
        fill-rule="evenodd"
        d="M1.646 4.646a.5.5 0 0 1 .708 0L8 10.293l5.646-5.647a.5.5 0 0 1 .708.708l-6 6a.5.5 0 0 1-.708 0l-6-6a.5.5 0 0 1 0-.708z"
    />
</svg>
