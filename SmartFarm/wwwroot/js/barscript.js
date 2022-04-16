(() => {
  // *****************Variables*****************
  let user_Adafruit1={
    aIO_key:"aio_RwUa43pnuNWSfUX1gTKfm0tiIR7v",
    Name:"luucongdinh"
  };
  let max_threshold = document.getElementById("max").getAttribute("max"),
      min_threshold = document.getElementById("min").getAttribute("min");
  const MONTHS = [
    "Tháng 1",
    "Tháng 2",
    "Tháng 3",
    "Tháng 4",
    "Tháng 5",
    "Tháng 6",
    "Tháng 7",
    "Tháng 8",
    "Tháng 9",
    "Tháng 10",
    "Tháng 11",
    "Tháng 12",
  ];

  const dataGroups = MONTHS.map((el) => {
    return { month: el, maxNumber: 0, minNumber: 0, number: 0 };
  });
  
  const year =new Date().getFullYear();
  let fromDate = new Date(`January 01, ${year}`);
  let toDate = new Date(`January 01, ${year + 1}`);

  //   **************DISPLAY CHART*****************
  getDataAdafruitInInterval(
    user_Adafruit.aIO_key,
    user_Adafruit.Name,
    document.querySelector('#feed').getAttribute("value"),
    1,
    fromDate,
    toDate
  ).then((res) => {
    const dataset = res.data;
    console.log(dataset);
    dataset.forEach((element) => {
      // console.log(element[0]);
      const month = new Date(element[0]).getMonth();
      dataGroups[month].number++;
      dataGroups[month].maxNumber =
        element[1] >= max_threshold
          ? ++dataGroups[month].maxNumber
          : dataGroups[month].maxNumber;
      dataGroups[month].minNumber =
        element[1] <= min_threshold
          ? ++dataGroups[month].minNumber
          : dataGroups[month].minNumber;
    });

    // console.log(dataGroups);

    const data = {
      labels: MONTHS,
      datasets: [
        {
          label: `Tổng`,
          data: dataGroups.map((el) => el.number),
          borderColor: "rgb(0,0,0,0.7)",
          backgroundColor: "#7bc36c",
        },
        {
          label: `Vượt ngưỡng max`,
          data: dataGroups.map((el) => el.maxNumber),
          borderColor: "rgb(0,0,0,0.7)",
          backgroundColor: "rgb(202, 37, 37)",
        },
        {
          label: `Vượt ngưỡng min`,
          data: dataGroups.map((el) => el.minNumber),
          borderColor: "rgb(0,0,0,0.7)",
          backgroundColor: "rgb(62, 128, 172)",
        },
      ],
    };

    const config = {
      type: "bar",
      data: data,
      plugins: [ChartDataLabels],
      options: {
        plugins: {
          legend: {
            position: "top",
          },
          datalabels: {
            color: "#000",
          },
          title: {
            display: true,
            text: `Biểu đồ so sánh số lần vượt ngưỡng ở các tháng trong năm ${year}`,
          },
        },
      },
    };
    // console.log(2);
    const myChart2 = new Chart(document.getElementById("myChart2"), config);
  });
})();
