import axios from "axios";

const API_URL =
    `${import.meta.env.VITE_API_BASE_URL}/invoices`;

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