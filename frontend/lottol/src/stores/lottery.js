import { ref, computed } from "vue";
import { defineStore } from "pinia";

export const useLotteryStore = defineStore("lottery", () => {
  const types = ref([
    "Ötös Lottó",
    "Hatos Lottó",
    "Skandináv Lottó",
    "EuroJackpot",
  ]);
  const getPic = (name) => {
    return "lotto" + (types.value.indexOf(name) + 5) + ".png";
  };
  const selectedLotteryList = ref([]);

  const selectLottery = (name) => {
    selectedLotteryList.value.push(name);
  };

  const emptyLotteryList = () => {
    selectedLotteryList.value = [];
  };
  return {
    types,
    getPic,
    selectedLotteryList,
    selectLottery,
    emptyLotteryList,
  };
});
