import { useEffect, useState } from 'react';
import { Card, CardHeader, CardTitle, CardDescription } from "@/components/ui/card";
import Image from "next/image";

interface Signal {
  symbolCode: string;
  lastPrice: number;
  topPriceChange: number;
  volumeChange: number;
  volume: number;
  typeId: number;
  eventTime: string;
  isUp: boolean;
  trackType: number;
  description: string;
}

export function SignalsList() {
  const [signals, setSignals] = useState<Signal[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const getImagePath = (symbolCode: string) => {
    // Remove USDT and convert to lowercase
    const baseSymbol = symbolCode.replace('USDT', '').toLowerCase();
    return `/img/${baseSymbol}.png`;
  };

  useEffect(() => {
    const fetchSignals = async () => {
      try {
        const response = await fetch('https://api.coininsight.app/Signal/lastSignals');
        if (!response.ok) {
          throw new Error('Failed to fetch signals');
        }
        const data = await response.json();
        setSignals(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to fetch signals');
      } finally {
        setLoading(false);
      }
    };

    fetchSignals();
    // Refresh data every minute
    const interval = setInterval(fetchSignals, 60000);
    return () => clearInterval(interval);
  }, []);

  if (loading) {
    return <div className="text-center">Loading signals...</div>;
  }

  if (error) {
    return <div className="text-red-500">Error: {error}</div>;
  }

  return (
    <div className="space-y-4 max-h-[600px] overflow-y-auto">
      {signals.map((signal, index) => (
        <div key={index} className="p-[1px] rounded-lg bg-gradient-to-r from-pink-700 via-purple-800 to-indigo-900">
          <Card className="p-4 hover:shadow-lg transition-shadow duration-200 bg-white dark:bg-gray-950 rounded-lg h-[100px]">
            <CardHeader className="p-0 h-full">
              <div className="flex items-start space-x-4 h-full">
                <div className="relative w-8 h-8 flex-shrink-0">
                  <Image
                    src={getImagePath(signal.symbolCode)}
                    alt={signal.symbolCode}
                    width={32}
                    height={32}
                    className="rounded-full"
                    onError={(e) => {
                      // Fallback to a default image if the crypto icon fails to load
                      (e.target as HTMLImageElement).src = '/img/default.png';
                    }}
                  />
                </div>
                <div className="flex-grow flex flex-col justify-between h-full">
                  <div>
                    <div className="flex justify-between items-start">
                      <div>
                        <CardTitle className="text-base font-semibold flex items-center">
                          {signal.symbolCode}
                        </CardTitle>
                        <CardDescription className="mt-0.5 text-xs line-clamp-2">{signal.description}</CardDescription>
                      </div>
                      <div className="text-right">
                        <div className="font-medium text-sm">${signal.lastPrice}</div>
                      </div>
                    </div>
                  </div>
                  <div className="text-[10px] text-gray-500">
                    {new Date(signal.eventTime).toLocaleString()}
                  </div>
                </div>
              </div>
            </CardHeader>
          </Card>
        </div>
      ))}
    </div>
  );
} 