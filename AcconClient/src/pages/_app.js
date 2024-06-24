import "@/styles/globals.css";
import Layout from "@/Layout/Layout";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import {ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
export default function App({Component, pageProps}) {
    return <>
        <Layout>
            <Component {...pageProps} />
            <ToastContainer />
        </Layout>
    </>
}
