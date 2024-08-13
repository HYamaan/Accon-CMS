import Head from "next/head";
import React, { memo } from "react";
import axios from "axios";
import https from "https";
import dynamic from 'next/dynamic';

const HomePage = dynamic(() => import("@/pages/Home"));

const Home = ({ pageInformation, ogImage, siteUrl, structuredData }) => {
  return (
      <>
        <Head>
          <title>{pageInformation.metaTitle}</title>
          <meta name="description" content={pageInformation.metaDescription} />
          <meta property="og:title" content={pageInformation.metaTitle} />
          <meta property="og:description" content={pageInformation.metaDescription} />
          <meta property="og:image" content={ogImage} />
          <meta property="og:url" content={siteUrl} />
          <meta name="twitter:card" content="summary_large_image" />
          <meta name="twitter:title" content={pageInformation.metaTitle} />
          <meta name="twitter:description" content={pageInformation.metaDescription} />
          <meta name="twitter:image" content={ogImage} />
          <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
        </Head>
        <HomePage data={pageInformation} />
      </>
  );
};

export default React.memo(Home);

export const getServerSideProps = async ({ req }) => {
  const protocol = req.headers['x-forwarded-proto'] || 'http';
  const host = req.headers.host;
  const siteUrl = `${protocol}://${host}`;
  const ogImage = `${siteUrl}/banner_service.jpg`;
  const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

  const axiosInstance = axios.create({
    httpsAgent: new https.Agent({
      rejectUnauthorized: false
    })
  });

  try {
    const getHomePage = await axiosInstance.get(`${process.env.NEXT_PUBLIC_API_URL}/Cms/GetHomeClientPage`);
    if (getHomePage.data.succeeded === false || !getHomePage.data.data) {
      return {
        redirect: {
          destination: '/404',
          permanent: false
        }
      }
    } else {
      const homePage = getHomePage.data.data;
      const structuredData = {
        "@context": "https://schema.org",
        "@type": "WebSite",
        "url": siteUrl,
        "name": homePage.metaTitle,
        "description": homePage.metaDescription,
        "publisher": {
          "@type": "Organization",
          "name": companyName,
          "url": siteUrl,
          "logo": {
            "@type": "ImageObject",
            "url": siteUrl
          }
        }
      };

      return {
        props: {
          ogImage,
          siteUrl,
          structuredData,
          pageInformation: homePage
        }
      };
    }
  } catch (error) {
    return {
      redirect: {
        destination: '/500',
        permanent: false
      }
    };
  }
};

