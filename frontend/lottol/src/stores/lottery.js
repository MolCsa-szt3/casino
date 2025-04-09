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

  const desc = ref([
    "Az Ötöslottó játékban 90 számból kell 5-öt kiválasztani.",
    "A Hatoslottó Játékban 45 zámból kell 6-ot kiválasztani.",
    "A Skandináv Lottó játékban 35 számból kell 7 számot kiválasztani.",
    "Az EuroJackpot játékban 50 számból kell 5-öt és 12-ből 2-őt kiválastani.",
  ]);

  const getDesc = (name) => {
    return desc.value[types.value.indexOf(name)];
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
    desc,
    getDesc,
  };
});
