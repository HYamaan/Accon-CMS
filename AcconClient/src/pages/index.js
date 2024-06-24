import HomePage from "@/pages/Home";
import Head from "next/head";
import React from "react";


export default function Home({ siteTitle, siteDescription, ogImage, siteUrl, structuredData }) {
  return <>
    <Head>
      <title>{siteTitle}</title>
      <meta name="description" content={siteDescription} />
      <meta property="og:title" content={siteTitle} />
      <meta property="og:description" content={siteDescription} />
      <meta property="og:image" content={ogImage} />
      <meta property="og:url" content={siteUrl} />
      <meta name="twitter:card" content="summary_large_image" />
      <meta name="twitter:title" content={siteTitle} />
      <meta name="twitter:description" content={siteDescription} />
      <meta name="twitter:image" content={ogImage} />
      <script type="application/ld+json" dangerouslySetInnerHTML={{ __html: JSON.stringify(structuredData) }} />
    </Head>
  <HomePage/>
  </>
}
export const getServerSideProps = async ({ req }) => {
  const protocol = req.headers['x-forwarded-proto'] || 'http';
  const host = req.headers.host;
  const siteUrl = `${protocol}://${host}`;
  const siteTitle = "Accon";
  const siteDescription = "Welcome to Your Company Name. Discover our services, portfolio, experience, and latest updates.";
  const ogImage = `${siteUrl}/banner_service.jpg`;
  const companyName = process.env.NEXT_PUBLIC_COMPANY_NAME;

  const structuredData = {
    "@context": "https://schema.org",
    "@type": "WebSite",
    "url": siteUrl,
    "name": siteTitle,
    "description": siteDescription,
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
      siteTitle,
      siteDescription,
      ogImage,
      siteUrl,
      structuredData
    }
  };
};
