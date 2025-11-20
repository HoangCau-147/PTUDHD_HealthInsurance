import React from 'react';
import { Chart as ChartJS, CategoryScale, LinearScale, ArcElement, BarElement, Title, Tooltip, Legend } from 'chart.js';
import { Bar, Pie } from 'react-chartjs-2';

import './Chart.scss';

ChartJS.register(ArcElement, CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend);

export const optionsbarchart = {
    responsive: true,
    plugins: {
        legend: {
            position: 'top',
        },
        title: {
            display: true,
            text: '',
        },
    },
};

export const optionspiechart = {
    responsive: true,
    plugins: {
        legend: {
            position: 'right',
        },
        title: {
            display: true,
            text: '',
        },
    },
};

const labels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
export const data = {
    labels,
    datasets: [
        {
            label: 'Số tiền thanh toán',
            data: [0, 1, 1, 3, 4, 5],
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
        },
        {
            label: 'Số tiền được hỗ trợ',
            data: [0, 1, 2, 3, 4, 5],
            backgroundColor: 'rgba(53, 162, 235, 0.5)',
        },
    ],
};

const charttemp = () => {
    return (
        <div className="spend">
            <span>Biểu đồ chi tiêu</span>
            <div className="chart">
                <div className="barchart">
                    <Bar options={optionsbarchart} data={data} />
                </div>
                <div className="piechart">
                    <Pie options={optionspiechart} data={data} />
                </div>
            </div>
        </div>
    );
};

export default charttemp;
