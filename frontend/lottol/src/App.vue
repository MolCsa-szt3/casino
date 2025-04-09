<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <nav class="row justify-content-center">
      <RouterLink class="btn btn-outline-success col-2 m-3" to="/"
        >Lottók</RouterLink
      >
      <RouterLink class="btn btn-outline-success col-2 m-3" to="/games"
        >Játék</RouterLink
      >
    </nav>
  </header>

  <RouterView />
</template>
