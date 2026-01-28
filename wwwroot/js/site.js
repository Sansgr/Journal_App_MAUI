function renderPieChart(canvasId, labels, data) {
    new Chart(document.getElementById(canvasId), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#28a745', '#ffc107', '#dc3545', '#007bff', '#17a2b8']
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

function generateSingleJournalPdf(entry) {
    const doc = new jspdf.jsPDF();
    doc.setFont("helvetica", "normal");

    doc.setFontSize(16);
    doc.text(entry.Title || "Untitled", 10, 20);

    doc.setFontSize(10);
    doc.text("Date: " + new Date(entry.EntryDate).toLocaleDateString(), 10, 30);

    doc.setFontSize(12);
    doc.text(entry.Content || "", 10, 40, { maxWidth: 180 });

    doc.save((entry.Title || "JournalEntry") + ".pdf");
}

