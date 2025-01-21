import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vite.dev/config/
export default defineConfig(() => {
  return {
    server: {
      open: true,
      proxy: {
        "/api": {
          target: "https://localhost:5001",
          changeOrigin: true,
          secure: false,
        },
      },
    },
    build: {
      outDir: "build",
    },
    plugins: [react()],
  };
});
