
// this file is generated — do not edit it


/// <reference types="@sveltejs/kit" />

/**
 * Environment variables [loaded by Vite](https://vitejs.dev/guide/env-and-mode.html#env-files) from `.env` files and `process.env`. Like [`$env/dynamic/private`](https://kit.svelte.dev/docs/modules#$env-dynamic-private), this module cannot be imported into client-side code. This module only includes variables that _do not_ begin with [`config.kit.env.publicPrefix`](https://kit.svelte.dev/docs/configuration#env) _and do_ start with [`config.kit.env.privatePrefix`](https://kit.svelte.dev/docs/configuration#env) (if configured).
 * 
 * _Unlike_ [`$env/dynamic/private`](https://kit.svelte.dev/docs/modules#$env-dynamic-private), the values exported from this module are statically injected into your bundle at build time, enabling optimisations like dead code elimination.
 * 
 * ```ts
 * import { API_KEY } from '$env/static/private';
 * ```
 * 
 * Note that all environment variables referenced in your code should be declared (for example in an `.env` file), even if they don't have a value until the app is deployed:
 * 
 * ```
 * MY_FEATURE_FLAG=""
 * ```
 * 
 * You can override `.env` values from the command line like so:
 * 
 * ```bash
 * MY_FEATURE_FLAG="enabled" npm run dev
 * ```
 */
declare module '$env/static/private' {
	export const PATH: string;
	export const XAUTHORITY: string;
	export const XDG_DATA_DIRS: string;
	export const GDMSESSION: string;
	export const DBUS_SESSION_BUS_ADDRESS: string;
	export const XDG_CURRENT_DESKTOP: string;
	export const INSIDE_NEMO_PYTHON: string;
	export const COLORTERM: string;
	export const SESSION_MANAGER: string;
	export const LOGNAME: string;
	export const PWD: string;
	export const LANGUAGE: string;
	export const GJS_DEBUG_TOPICS: string;
	export const SHELL: string;
	export const GIO_LAUNCHED_DESKTOP_FILE: string;
	export const GNOME_DESKTOP_SESSION_ID: string;
	export const GTK_MODULES: string;
	export const XDG_SESSION_PATH: string;
	export const NODE_ENV: string;
	export const DOTNET_BUNDLE_EXTRACT_BASE_DIR: string;
	export const XDG_SESSION_DESKTOP: string;
	export const SHLVL: string;
	export const FORCE_COLOR: string;
	export const XDG_CONFIG_DIRS: string;
	export const LANG: string;
	export const XDG_SEAT_PATH: string;
	export const DEBUG_COLORS: string;
	export const XDG_SESSION_ID: string;
	export const XDG_SESSION_TYPE: string;
	export const npm_config_color: string;
	export const DISPLAY: string;
	export const MOCHA_COLORS: string;
	export const CINNAMON_VERSION: string;
	export const XDG_SESSION_CLASS: string;
	export const GDM_LANG: string;
	export const GTK3_MODULES: string;
	export const XDG_GREETER_DATA_DIR: string;
	export const GPG_AGENT_INFO: string;
	export const DESKTOP_SESSION: string;
	export const USER: string;
	export const GIO_LAUNCHED_DESKTOP_FILE_PID: string;
	export const QT_ACCESSIBILITY: string;
	export const GJS_DEBUG_OUTPUT: string;
	export const SSH_AUTH_SOCK: string;
	export const XDG_SEAT: string;
	export const QT_QPA_PLATFORMTHEME: string;
	export const XDG_VTNR: string;
	export const XDG_RUNTIME_DIR: string;
	export const HOME: string;
}

/**
 * Similar to [`$env/static/private`](https://kit.svelte.dev/docs/modules#$env-static-private), except that it only includes environment variables that begin with [`config.kit.env.publicPrefix`](https://kit.svelte.dev/docs/configuration#env) (which defaults to `PUBLIC_`), and can therefore safely be exposed to client-side code.
 * 
 * Values are replaced statically at build time.
 * 
 * ```ts
 * import { PUBLIC_BASE_URL } from '$env/static/public';
 * ```
 */
declare module '$env/static/public' {
	
}

/**
 * This module provides access to runtime environment variables, as defined by the platform you're running on. For example if you're using [`adapter-node`](https://github.com/sveltejs/kit/tree/master/packages/adapter-node) (or running [`vite preview`](https://kit.svelte.dev/docs/cli)), this is equivalent to `process.env`. This module only includes variables that _do not_ begin with [`config.kit.env.publicPrefix`](https://kit.svelte.dev/docs/configuration#env) _and do_ start with [`config.kit.env.privatePrefix`](https://kit.svelte.dev/docs/configuration#env) (if configured).
 * 
 * This module cannot be imported into client-side code.
 * 
 * ```ts
 * import { env } from '$env/dynamic/private';
 * console.log(env.DEPLOYMENT_SPECIFIC_VARIABLE);
 * ```
 * 
 * > In `dev`, `$env/dynamic` always includes environment variables from `.env`. In `prod`, this behavior will depend on your adapter.
 */
declare module '$env/dynamic/private' {
	export const env: {
		PATH: string;
		XAUTHORITY: string;
		XDG_DATA_DIRS: string;
		GDMSESSION: string;
		DBUS_SESSION_BUS_ADDRESS: string;
		XDG_CURRENT_DESKTOP: string;
		INSIDE_NEMO_PYTHON: string;
		COLORTERM: string;
		SESSION_MANAGER: string;
		LOGNAME: string;
		PWD: string;
		LANGUAGE: string;
		GJS_DEBUG_TOPICS: string;
		SHELL: string;
		GIO_LAUNCHED_DESKTOP_FILE: string;
		GNOME_DESKTOP_SESSION_ID: string;
		GTK_MODULES: string;
		XDG_SESSION_PATH: string;
		NODE_ENV: string;
		DOTNET_BUNDLE_EXTRACT_BASE_DIR: string;
		XDG_SESSION_DESKTOP: string;
		SHLVL: string;
		FORCE_COLOR: string;
		XDG_CONFIG_DIRS: string;
		LANG: string;
		XDG_SEAT_PATH: string;
		DEBUG_COLORS: string;
		XDG_SESSION_ID: string;
		XDG_SESSION_TYPE: string;
		npm_config_color: string;
		DISPLAY: string;
		MOCHA_COLORS: string;
		CINNAMON_VERSION: string;
		XDG_SESSION_CLASS: string;
		GDM_LANG: string;
		GTK3_MODULES: string;
		XDG_GREETER_DATA_DIR: string;
		GPG_AGENT_INFO: string;
		DESKTOP_SESSION: string;
		USER: string;
		GIO_LAUNCHED_DESKTOP_FILE_PID: string;
		QT_ACCESSIBILITY: string;
		GJS_DEBUG_OUTPUT: string;
		SSH_AUTH_SOCK: string;
		XDG_SEAT: string;
		QT_QPA_PLATFORMTHEME: string;
		XDG_VTNR: string;
		XDG_RUNTIME_DIR: string;
		HOME: string;
		[key: `PUBLIC_${string}`]: undefined;
		[key: `${string}`]: string | undefined;
	}
}

/**
 * Similar to [`$env/dynamic/private`](https://kit.svelte.dev/docs/modules#$env-dynamic-private), but only includes variables that begin with [`config.kit.env.publicPrefix`](https://kit.svelte.dev/docs/configuration#env) (which defaults to `PUBLIC_`), and can therefore safely be exposed to client-side code.
 * 
 * Note that public dynamic environment variables must all be sent from the server to the client, causing larger network requests — when possible, use `$env/static/public` instead.
 * 
 * ```ts
 * import { env } from '$env/dynamic/public';
 * console.log(env.PUBLIC_DEPLOYMENT_SPECIFIC_VARIABLE);
 * ```
 */
declare module '$env/dynamic/public' {
	export const env: {
		[key: `PUBLIC_${string}`]: string | undefined;
	}
}