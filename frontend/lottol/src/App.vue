<script setup>
import { RouterLink, RouterView } from "vue-router";
</script>

<template>
  <header>
    <nav>
      <RouterLink class="btn btn-outline-success" to="/">Lottók</RouterLink>
      <RouterLink class="btn btn-outline-success" to="/games">Játék</RouterLink>
    </nav>
  </header>

  <RouterView />
</template>
