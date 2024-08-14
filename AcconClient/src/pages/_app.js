import "@/styles/globals.css";
import Layout from "@/Layout/Layout";
import AdminLayout from "@/Layout/AdminLayout";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { useRouter } from 'next/router';
import { Provider } from "react-redux";
import store from "@/redux/store";
import { getCookie } from 'cookies-next';
import Login from "@/Components/Admin/LoginPage/Login";
export default function App({ Component, pageProps }) {
    const router = useRouter();
    const isAdminRoute = router.pathname.startsWith('/admin');
    const adminToken = getCookie('accessToken');
    const getLayout = (page) => {
        if ((adminToken === null || adminToken == undefined) && isAdminRoute) {
            return <>
                <Login/>
                <ToastContainer/>
            </>
        }
        else if (isAdminRoute) {
            return (
                <AdminLayout>
                    {page}
                    <ToastContainer />
                </AdminLayout>
            );
        }else{
        return (
            <Layout>
                {page}
                <ToastContainer />
            </Layout>
        );
        }
    };

    return (
        <Provider store={store}>
            {getLayout(<Component {...pageProps} />)}
        </Provider>
    );
}
