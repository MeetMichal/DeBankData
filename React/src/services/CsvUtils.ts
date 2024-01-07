import axios from 'axios';
import Papa from 'papaparse';

const csvTextFromUrl = async (url: string): Promise<string> => {
    try {
        const { data } = await axios.get(url);
        return data;
    } catch (error: any) {
        console.log(error);
        return error.message;
    }
};

export const getData = async <T>(url: string): Promise<T[]> => {
    const csvText: string = await csvTextFromUrl(process.env.PUBLIC_URL+url);
    const { data } = Papa.parse(csvText, { header: true, skipEmptyLines: true, dynamicTyping:true});
    return data as T[];
};