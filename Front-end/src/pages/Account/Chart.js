import React, { useState, useEffect } from 'react';
import { PieChart, Pie, BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';
import './ChartStyle.scss';

import { ContractsCustomerApi, AccountCustomerApi, totalFeeByYearApi, totalFeeForRequestApi } from '../../services/ApiAccount/Account'



const Chart = () => {
    //barchar
    let dataBarCharDefault = [
        {
            month: 1,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 2,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 3,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 4,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 5,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 6,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 7,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 8,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 9,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 10,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 11,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
        {
            month: 12,
            "đã thanh toán": 0,
            "yêu cầu": 0,
        },
    ];

    // Pie chart
    const dataPieChartInsuranceDefault = [
        { name: 'Đang thụ hưởng', value: 100 },
        { name: 'Hết hạn', value: 200 },
    ];
    const dataPieChartRequestDefault = [
        { name: 'Chưa thanh toán', value: 100 },
        { name: 'Đã được thanh toán', value: 300 },
    ];
    const [dataBarChart, setDataBarChart] = useState({});
    const [dataPieChartInsurance, setDataPieChartInsurance] = useState(dataPieChartInsuranceDefault);
    const [dataPieChartRequest, setSataPieChartRequest] = useState({});
    const [userData, setUserData] = useState({});
    const [contractsOfCustomer, setContractsOfCustomer] = useState([]);
    const [contractsUsingOfCustomer, setContractsUsingOfCustomer] = useState([]);
    const [contractsExpiredOfCustomer, setContractsExpiredOfCustomer] = useState([]);
    const [yearsInContract, setYearsInContract] = useState([]);
    const [selectedYear, setSelectedYear] = useState('');
    useEffect(() => {
        fetchData();
    }, [selectedYear]);

    useEffect(() => {
        if (!selectedYear && yearsInContract.length > 0) {
            // Set selectedYear to the first year in the array
            setSelectedYear(String(yearsInContract[0]));
        } else {
            // Call the function with selectedYear
            dataBarChartBYear(selectedYear);
        }
    }, [selectedYear, yearsInContract]);
    const fetchData = async () => {
        try {
            const user = localStorage.getItem('token');
            // Phân tách token thành ba phần: Header, Payload, Signature
            let parts = user.split('.');
            const role = localStorage.getItem('role');

            // Giải mã Payload
            let decodedPayload = JSON.parse(atob(parts[1]));

            // Lấy giá trị của thuộc tính "emailaddress"
            let emailAddress = decodedPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
            if (role === "Customer") {
                const customer = await AccountCustomerApi(emailAddress);
                setUserData(customer);
                const contractUsings = await ContractsCustomerApi(customer.customerId, 2);
                const listTotalFeeForRequest = await totalFeeForRequestApi(customer.customerId);
                const contractExpireds = await ContractsCustomerApi(customer.customerId, 3);
                const contracts = contractUsings.concat(contractExpireds);
                if (yearsInContract) {
                    setYearsInContract([]);
                }
                if (contractUsings) {
                    setContractsUsingOfCustomer(contractUsings);
                }

                if (contractExpireds) {
                    setContractsExpiredOfCustomer(contractExpireds);
                }
                if (contracts) {
                    setContractsOfCustomer(contracts);
                    const uniqueYearsArray = [...new Set(
                        contracts
                            .filter(contract => contract.confirmDate && !isNaN(new Date(contract.confirmDate)))
                            .map(contract => {
                                const year = new Date(contract.confirmDate).getFullYear();
                                return year;
                            })
                    )];
                    setYearsInContract(uniqueYearsArray.sort((a, b) => a - b));
                    if (!selectedYear && uniqueYearsArray.length > 0) {
                        // Set selectedYear to the first year in the array
                        setSelectedYear(String(uniqueYearsArray[0]));
                    }
                }
                updateDataPieChartInsurance();
                updateDataPieChartRequest(listTotalFeeForRequest);
            }
        } catch (error) {
            console.log(error);
        }
    }
    const dataBarChartBYear = async (year) => {
        if (year) {
            try {
                // Gọi hàm API để lấy dữ liệu mới dựa trên năm được chọn
                const dataForChart = await totalFeeByYearApi(userData.customerId, selectedYear);
                console.log("check dataForChart: ", dataForChart);
                // Cập nhật state của dataBarChart
                setDataBarChart(dataForChart.data);
            } catch (error) {
                console.error("Error fetching or updating data:", error);
                // Xử lý lỗi nếu có
            }
        }

    }
    const calculateTotalPrice = (contracts) => {
        return contracts.reduce((total, contract) => total + contract.totalPrice, 0);
    };

    const updateDataPieChartRequest = (listTotalFeeForRequest) => {
        const newDataArray = listTotalFeeForRequest.map(item => ({
            name: item.status === 0 ? 'Chưa thanh toán' : 'Đã được thanh toán',
            value: item.total,
        }));
        setSataPieChartRequest(newDataArray);
    }

    const updateDataPieChartInsurance = () => {
        // Tính tổng totalPrice cho contractsUsingOfCustomer
        const totalUsing = calculateTotalPrice(contractsUsingOfCustomer);

        // Tính tổng totalPrice cho contractsExpiredOfCustomer
        const totalExpired = calculateTotalPrice(contractsExpiredOfCustomer);

        // Cập nhật giá trị cho dataPieChartInsurance
        setDataPieChartInsurance([
            { name: 'Đang thụ hưởng', value: totalUsing },
            { name: 'Hết hạn', value: totalExpired },
        ]);
    };


    const handleSelectChange = async (event) => {
        setSelectedYear(event.target.value);
        //dataChartBYear(event.target.value);

    };
    return (
        <div className="spend">
            {/* <span style={{ marginBottom: '20px' }}>Biểu đồ chi tiêu</span> */}
            <div className="insurance_policy">
                <span>
                    Chọn năm <span style={{ color: 'red' }}> *</span>
                </span>
                <select
                    value={selectedYear}
                    onChange={handleSelectChange}
                    style={{ textAlign: 'center' }}
                >
                    {/* Hiển thị các năm từ mảng */}
                    {yearsInContract.map((year, index) => (
                        <option key={index} value={year}>
                            {year}
                        </option>
                    ))}
                </select>
            </div>
            <div className="chart">
                <div className="barchart">
                    <BarChart
                        width={500}
                        height={300}
                        data={dataBarChart && dataBarChart.length > 0 ? dataBarChart : dataBarCharDefault}
                        margin={{
                            top: 5,
                            right: 30,
                            left: 20,
                            bottom: 5,
                        }}
                    >
                        <CartesianGrid strokeDasharray="3 3" />
                        <XAxis dataKey="month" />
                        <YAxis domain={[0, 'dataMax']} />
                        <Tooltip />
                        <Legend />
                        <Bar dataKey="contract" fill="#82ca9d" name="Đã thanh toán" />
                        <Bar dataKey="request" fill="#8884d8" name="Yêu cầu" />
                    </BarChart>
                </div>
                <div className="piechart">
                    <PieChart width={400} height={400}>
                        <Tooltip formatter={(value, name) => [value, name]} />
                        <Pie data={dataPieChartInsurance ? dataPieChartInsurance : dataPieChartInsuranceDefault} dataKey="value" cx={200} cy={200} outerRadius={60} fill="#8884d8" />
                        <Pie
                            data={dataPieChartRequest ? dataPieChartRequest : dataPieChartRequestDefault}
                            dataKey="value"
                            cx={200}
                            cy={200}
                            innerRadius={70}
                            outerRadius={90}
                            fill="#82ca9d"
                            label
                        />
                    </PieChart>
                </div>
            </div>
        </div>
    );
};

export default Chart;
