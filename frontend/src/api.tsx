import axios from "axios";
import { CompanyBalanceSheet, CompanyCashFlow, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile, CompanySearch } from "./company"


interface SearchResponse {
    data: CompanySearch[];
}

const API_KEY = process.env.REACT_APP_API_KEY;

export const searchCompanies = async (query: string) => {
    try {
        const data = await axios.get<SearchResponse>(
            `https://financialmodelingprep.com/api/v3/search-ticker?query=${query}&limit=10&exchange=NASDAQ&apikey=${API_KEY}`
        )
        return data;
    } catch (error) {
        if(axios.isAxiosError(error)){
            console.log("Error Message: ", error.message)
        } else {
            console.log("Error: ", error)
            return "An unexpected error has occurred."
        }
    }
}

export const getCompanyProfile = async (query: string) => {
    try {
        const data = await axios.get<CompanyProfile[]>(
            `https://financialmodelingprep.com/api/v3/profile/${query}?apikey=${API_KEY}`
        )
        return data;
    } catch (error : any) {
        console.log("Error message from API,", error.message);
    }
}

export const getKeyMetrics = async (query: string) => {
    try {
        const data = await axios.get<CompanyKeyMetrics[]>(
            `https://financialmodelingprep.com/api/v3/key-metrics-ttm/${query}?apikey=${API_KEY}`
        )
        return data;
    } catch (error : any) {
        console.log("Error message from API,", error.message);
    }
}

export const getIncomeStatement = async (query: string) => {
    try {
        const data = await axios.get<CompanyIncomeStatement[]>(
            `https://financialmodelingprep.com/api/v3/income-statement/${query}?limit=40&apikey=${API_KEY}`
        )
        return data;
    } catch (error : any) {
        console.log("Error message from API,", error.message);
    }
}

export const getBalanceSheet = async (query: string) => {
    try {
        const data = await axios.get<CompanyBalanceSheet[]>(
            `https://financialmodelingprep.com/api/v3/balance-sheet-statement/${query}?limit=40&apikey=${API_KEY}`
        )
        return data;
    } catch (error : any) {
        console.log("Error message from API,", error.message);
    }
}

export const getCashflow = async (query: string) => {
    try {
        const data = await axios.get<CompanyCashFlow[]>(
            `https://financialmodelingprep.com/api/v3/cash-flow-statement${query}?limit=40&apikey=${API_KEY}`
        )
        return data;
    } catch (error : any) {
        console.log("Error message from API,", error.message);
    }
}