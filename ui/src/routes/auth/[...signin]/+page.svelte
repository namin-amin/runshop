<script>
    import IoLogoFacebook from "svelte-icons/io/IoLogoFacebook.svelte";
    import IoLogoGoogle from "svelte-icons/io/IoLogoGoogle.svelte";
</script>

<form
    class="flex flex-col gap-3 justify-center items-center w-2/5 h-4/5 shadow-2xl rounded-lg p-5 box-border"
>
    <img src="/chat.png" alt="logo" class="aspect-square w-32 justify-start" />
    <h1 class="text-2xl m-5">Open Chat</h1>
    <div class="flex flex-col justify-center items-center w-full gap-7">
        <input
            type="text"
            class="input input-accent w-2/3"
            placeholder="Email/Username"
        />
        <input
            type="password"
            class="input input-accent w-2/3"
            placeholder="Password"
        />
    </div>

    <button type="submit" class="btn btn-accent w-32">SingIn</button>
    <p>OR</p>
    <div class="flex gap-5 border rounded-xl p-2 bg-secondary">
        <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            class="bi bi-google text-primary w-10 h-10"
            viewBox="0 0 16 16"
        >
            <path
                d="M15.545 6.558a9.42 9.42 0 0 1 .139 1.626c0 2.434-.87 4.492-2.384 5.885h.002C11.978 15.292 10.158 16 8 16A8 8 0 1 1 8 0a7.689 7.689 0 0 1 5.352 2.082l-2.284 2.284A4.347 4.347 0 0 0 8 3.166c-2.087 0-3.86 1.408-4.492 3.304a4.792 4.792 0 0 0 0 3.063h.003c.635 1.893 2.405 3.301 4.492 3.301 1.078 0 2.004-.276 2.722-.764h-.003a3.702 3.702 0 0 0 1.599-2.431H8v-3.08h7.545z"
            />
        </svg>

        <svg
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            class="bi bi-facebook text-primary w-10 h-10"
            viewBox="0 0 16 16"
        >
            <path
                d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z"
            />
        </svg>
    </div>
    <p>OR</p>
    <p>
        New user? 🤔 <a href="/auth/signup" class="link-primary">Signup</a>
    </p>
</form>
