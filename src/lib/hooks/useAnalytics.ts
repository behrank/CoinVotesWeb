'use client';

import { useEffect, useState } from 'react';
import { Analytics, logEvent } from 'firebase/analytics';
import { analytics } from '../firebase';

export const useAnalytics = () => {
  const [analyticsInstance, setAnalyticsInstance] = useState<Analytics | null>(null);

  useEffect(() => {
    // Initialize analytics when the component mounts
    if (analytics) {
      analytics.then((analyticsInstance) => {
        setAnalyticsInstance(analyticsInstance);
      });
    }
  }, []);

  const logAnalyticsEvent = (
    eventName: string,
    eventParams?: { [key: string]: string | number | boolean }
  ) => {
    if (analyticsInstance) {
      logEvent(analyticsInstance, eventName, eventParams);
    }
  };

  return { logAnalyticsEvent };
}; 