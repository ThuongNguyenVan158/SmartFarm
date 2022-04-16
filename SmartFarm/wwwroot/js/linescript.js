// /api/v2/{username}/feeds/{feed_key}/data/chart
// curl -H "X-AIO-Key: {io_key}" 'https://io.adafruit.com/api/v2/{username}/feeds/{feed_key}/data/chart?hours=1'

//*************CUSTOM variable******************* */
let user_Adafruit={
    aIO_key:"aio_RwUa43pnuNWSfUX1gTKfm0tiIR7v",
    Name:"luucongdinh"
}
//********************************************** */

const getDataAdafruitInInterval = function (
  userKey,
  userName,
  feedKey,
  resolution,
  fromDate,
  toDate,

  errorMsg = "Something went wrong"
) {
  const url = `https://io.adafruit.com/api/v2/${userName}/feeds/${feedKey}/data/chart?start_time=${fromDate}&end_time=${toDate}&resolution=${resolution}`;
  return fetch(url, {
    headers: {
      "X-Aio-Key": `${userKey}`,
    },
    method: "GET",
  })
    .then((response) => {
      if (!response.ok) throw new Error(`${errorMsg} ${response}`);
      //   if (!response.ok) return console.log(response);
      return response.json();
    })
    .then((response) => {
      return response;
    })
    .catch((err) => {
      return err;
    });
};

const getDataAdafruit = function (
  userKey,
  userName,
  feedKey,
  resolution,
  timeInSecond,
  errorMsg = "Something went wrong"
) {
  const hour = timeInSecond / (60 * 60);
  const url = `https://io.adafruit.com/api/v2/${userName}/feeds/${feedKey}/data/chart?hours=${hour}&resolution=${resolution}`;
  return fetch(url,{
    headers: {
      "X-Aio-Key": `${userKey}`,
    },
    method: "GET",
  }).then((response) => {
    //   if (!response.ok) return console.log(response);
    //   console.log(response.json());
    return response.json();
  });
};
//***************CHART DISPLAY**************** */
//*****From date to date****** */
function draw(fromDate,toDate)
{
  getDataAdafruitInInterval(
    user_Adafruit.aIO_key,
    user_Adafruit.Name,
    document.querySelector('#feed').getAttribute("value"),
    1,
    fromDate,
    toDate,
  ).then((res) => {
    var nameDevice=document.querySelector('#feed').getAttribute("name");
    var kind=document.querySelector('#feed').getAttribute("kind");
    let max_threshold = document.getElementById("max").getAttribute("max"),
      min_threshold = document.getElementById("min").getAttribute("min");
    console.log(res);
    const dataset = res.data;
    let labels = [],
      values = [],
      min = [],
      max = [],
      maxNumber = 0,
      minNumber = 0;
    dataset.forEach((element) => {
      // console.log(element[0]);
      labels.push(
        new Date(element[0]).toLocaleDateString("vi-VN", {
          // weekday: "short",
          year: "numeric",
          month: "numeric",
          day: "numeric",
          hour: "2-digit",
          minute: "2-digit",
          second: "2-digit",
        })
      );
      //Get number of point that exceed the threshold
      maxNumber = element[1] > max_threshold ? maxNumber + 1 : maxNumber;
      minNumber = element[1] < min_threshold ? minNumber + 1 : minNumber;
      values.push(element[1]);
      min.push(min_threshold);
      max.push(max_threshold);
    });
    const data = {
      labels: labels,
      datasets: [
        {
          label: `Humid (${dataset.length})`,
          data: values,
          fill: false,
          borderColor: "rgba(0,0,0,0.8)",
          // tension: 0.1,
          pointStyle: "circle",
          pointRadius: 5,
          pointHoverRadius: 12,
          pointBackgroundColor: function (context) {
            var index = context.dataIndex;
            var value = context.dataset.data[index];
            if (value >= max_threshold) return "rgb(202, 37, 37)";
            else if (value <= min_threshold) return "rgb(62, 128, 172)";
            else return "#7bc36c";
          },
        },
        {
          label: `Max (${maxNumber})`,
          data: max,
          fill: false,
          // borderColor: "rgba(45, 186, 58, 1)",
          // tension: 0.1,
          // pointStyle: "circle",
          pointRadius: 0,
          // pointHoverRadius: 0,
          backgroundColor: "rgb(202, 37, 37)",
          borderColor: "rgb(202, 37, 37)",
        },
        {
          label: `Min (${minNumber})`,
          data: min,
          fill: false,
          // borderColor: "rgba(45, 186, 58, 1)",
          // tension: 0.1,
          // pointStyle: "circle",
          pointRadius: 0,
          // pointHoverRadius: 0,
          backgroundColor: "rgb(62, 128, 172)",
          borderColor: "rgb(62, 128, 172)",
        },
      ],
    };

    const config = {
      type: "line",
      data: data,
      options: {
        // responsive: true,
        //   maintainAspectRadio: false,
        //   plugin: {
        //     legend: false,
        //   },
        scales: {
          x: {
            display: false,
          },
          y: {
            // stacked: true,
            // type: "log2",
          },
        },
        plugins: {
          decimation: {
            enabled: true,
          },
          title: {
            display: true,
            text: `Biểu đồ biểu diễn sự biến thiên thông số của thiết bị ${nameDevice} về ${kind} từ  ${new Date(
              fromDate
            ).toLocaleDateString("vi-VN")} đến ${new Date(
              toDate
            ).toLocaleDateString("vi-VN")}`,
          },
        },
      },
    };
    // console.log(myChart);
    // if(myChart!=undefined)
    // {
    //   console.log("dinh");
    //   myChart.destroy();
    // }
    document.getElementById("myChart").remove();
    document.getElementById("chart_line").insertAdjacentHTML("beforeend",'<canvas id="myChart"></canvas>');
    let mychart=new Chart(document.getElementById("myChart"), config);

  });
}
console.log("From_value: ",document.querySelector('.time._from').value);
console.log("To_value: ",document.querySelector('.time._to').value);

var From=document.querySelector('.time._from').value;
var To=document.querySelector('.time._to').value;

console.log("From: ",From);
console.log("To: ",To);

//From: 2022-01-31
let fromDate =new Date(From).toISOString(), //2022-01-31T20:24:00.000Z
  toDate = new Date(To+"T23:59:00").toISOString(); //2022-01-31T20:24;//2022-04-13T23:59:59.000Z
console.log("fromDate",fromDate);
console.log("toDate",toDate);

draw(fromDate,toDate);

document.querySelector('.button').onclick=function(e){
  console.log("From_value: ",document.querySelector('.time._from').value);
  console.log("To_value: ",document.querySelector('.time._to').value);
  
  From=document.querySelector('.time._from').value;
  To=document.querySelector('.time._to').value;

  console.log("From: ",From);
  console.log("To: ",To);

  //From: 2022-01-31
  fromDate =new Date(From).toISOString(); //2022-01-31T20:24:00.000Z
    toDate = new Date(To+"T23:59:00").toISOString(); //2022-01-31T20:24;//2022-04-13T23:59:59.000Z
  console.log("fromDate",fromDate);
  console.log("toDate",toDate);
  draw(fromDate,toDate);
}


