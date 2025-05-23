import type { Metadata } from "next";
import { Open_Sans } from "next/font/google";
import "./globals.css";
import { Footer } from "@/components/Footer";
import { useAnalytics } from "@/lib/hooks/useAnalytics";

const openSans = Open_Sans({ 
  subsets: ["latin"],
  display: 'swap',
});

export const metadata: Metadata = {
  metadataBase: new URL('https://coininsightweb.com'), // Replace with your actual domain
  title: {
    default: "CoinInsight - Your Smart Crypto Companion",
    template: "%s | CoinInsight"
  },
  description: "Track, analyze, and make informed decisions about your cryptocurrency investments with CoinInsight mobile app. Real-time crypto tracking, market analysis, and portfolio management.",
  keywords: ["cryptocurrency", "crypto tracking", "crypto portfolio", "bitcoin", "ethereum", "crypto analysis", "crypto market", "crypto investments", "crypto app"],
  authors: [{ name: "CoinInsight Team" }],
  creator: "CoinInsight",
  publisher: "CoinInsight",
  formatDetection: {
    email: false,
    telephone: false,
  },
  icons: {
    icon: '/img/logo.webp',
    apple: '/img/logo.webp',
  },
  openGraph: {
    type: 'website',
    siteName: 'CoinInsight',
    title: 'CoinInsight - Your Smart Crypto Companion',
    description: 'Track, analyze, and make informed decisions about your cryptocurrency investments with CoinInsight mobile app.',
    images: [
      {
        url: '/img/landing.png',
        width: 1200,
        height: 630,
        alt: 'CoinInsight App Preview'
      }
    ],
  },
  twitter: {
    card: 'summary_large_image',
    title: 'CoinInsight - Your Smart Crypto Companion',
    description: 'Track, analyze, and make informed decisions about your cryptocurrency investments with CoinInsight mobile app.',
    images: ['/img/landing.png'],
    creator: '@coininsight', // Replace with your actual Twitter handle
  },
  viewport: {
    width: 'device-width',
    initialScale: 1,
    maximumScale: 1,
  },
  verification: {
    google: 'your-google-verification-code', // Replace with your Google Search Console verification code
  },
  alternates: {
    canonical: 'https://coininsightweb.com', // Replace with your actual domain
  },
  robots: {
    index: true,
    follow: true,
    googleBot: {
      index: true,
      follow: true,
      'max-video-preview': -1,
      'max-image-preview': 'large',
      'max-snippet': -1,
    },
  },
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  // Initialize analytics
  useAnalytics();

  return (
    <html lang="en" className="dark">
      <body style={{ backgroundColor: '#070707' }} className={`${openSans.className} min-h-screen bg-background text-foreground antialiased flex flex-col`}>
        <main className="flex-grow">
          {children}
        </main>
        <Footer />
      </body>
    </html>
  );
}
