import axios from "axios";

const API_URL = "https://localhost:7120/api/invoices";

const getInvoices = async () => {

    const token =
        localStorage.getItem("token");

    return await axios.get(
        API_URL,
        {
            headers: {
                Authorization:
                    `Bearer ${token}`
            }
        }
    );
};

const createInvoice = async (invoice) => {

    const token =
        localStorage.getItem("token");

    return await axios.post(
        API_URL,
        invoice,
        {
            headers: {
                Authorization:
                    `Bearer ${token}`
            }
        }
    );
};


const invoiceService = {
    getInvoices,
    createInvoice
};

export default invoiceService;