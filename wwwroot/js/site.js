function renderPieChart(canvasId, labels, data) {
    new Chart(document.getElementById(canvasId), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#28a745', '#ffc107', '#dc3545']
            }]
        }
    });
}

function renderBarChart(canvasId, labels, data) {
    new Chart(document.getElementById(canvasId), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: '#007bff'
            }]
        }
    });
}

function renderLineChart(canvasId, labels, data) {
    new Chart(document.getElementById(canvasId), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                borderColor: '#17a2b8',
                fill: false
            }]
        }
    });
}
