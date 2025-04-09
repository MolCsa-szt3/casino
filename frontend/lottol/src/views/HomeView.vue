<script setup>
import { useLotteryStore } from "@/stores/lottery";
const lotteryStore = useLotteryStore();
</script>

<template>
  <main>
    <h1 class="text-center">Lottók</h1>
    <div class="container">
      <div class="row">
        <div
          v-for="lotto in lotteryStore.types"
          class="card col-md-6 col-lg-4 col-xl-3"
        >
          <div class="card-body">
            <h4 class="card-title">{{ lotto }}</h4>
            <img
              class="card-img-top"
              :src="lotteryStore.getPic(lotto)"
              alt="Card image"
            />
            <p class="card-text">TEsting makes me feel good</p>
            <button
              @click="lotteryStore.selectLottery(lotto)"
              class="btn btn-success"
            >
              Játtszom
            </button>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>
