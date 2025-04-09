<script setup>
import { useLotteryStore } from "@/stores/lottery";
const lotteryStore = useLotteryStore();
</script>

<template>
  <h1 class="text-center">Fogadások</h1>
  <div class="container border">
    <h5
      v-if="lotteryStore.selectedLotteryList.length == 0"
      class="text-danger text-center"
    >
      <b>Még nincs leadott fogadás.</b>
    </h5>
    <div v-else>
      <ul>
        <li v-for="selected in lotteryStore.selectedLotteryList">
          {{ selected }}
        </li>
      </ul>
      <button class="btn btn-danger" @click="lotteryStore.emptyLotteryList()">
        Lista törlése
      </button>
    </div>
  </div>
</template>

<style></style>
