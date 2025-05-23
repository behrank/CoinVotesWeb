import type { Metadata } from "next";
import { Open_Sans } from "next/font/google";
import "./globals.css";
import { Footer } from "@/components/Footer";

const openSans = Open_Sans({ 
  subsets: ["latin"],
  display: 'swap',
});

export const metadata: Metadata = {
  title: "CoinInsight - Your Smart Crypto Companion",
  description: "Track, analyze, and make informed decisions about your cryptocurrency investments with CoinInsight mobile app.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
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
