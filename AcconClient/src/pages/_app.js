import "@/styles/globals.css";
import Layout from "@/Layout/Layout";
import AdminLayout from "@/Layout/AdminLayout"; // Admin için farklı bir Layout
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import { useRouter } from 'next/router';

export default function App({ Component, pageProps }) {
    const router = useRouter();
    const isAdminRoute = router.pathname.startsWith('/admin');

    return (
        <>
            {isAdminRoute ? (
                <AdminLayout>
                    <Component {...pageProps} />
                    <ToastContainer />
                </AdminLayout>
            ) : (
                <Layout>
                    <Component {...pageProps} />
                    <ToastContainer />
                </Layout>
            )}
        </>
    );
}
