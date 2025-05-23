import { Navbar } from "@/components/Navbar";

export default function PrivacyPolicy() {
  return (
    <>
      <Navbar />
      <main className="min-h-screen pt-24 pb-16 px-6">
        <div className="mx-auto max-w-3xl">
          <h1 className="text-3xl font-bold mb-8">Privacy Policy</h1>
          
          <section className="space-y-6">
            <div>
              <h2 className="text-xl font-semibold mb-3">1. Introduction</h2>
              <p className="text-gray-400">
                This page informs you of our policies regarding the collection, use, and disclosure of Personal Information we receive from users of the app. We use your Personal Information only for providing and improving the App. By using the App, you agree to the collection and use of information in accordance with this policy.
              </p>
            </div>

            <div>
              <h2 className="text-xl font-semibold mb-3">2. Children's Privacy and Age Requirements</h2>
              <p className="text-gray-400">
                CoinInsight is not intended for children under the age of 13. We do not knowingly collect personally identifiable information from children under 13. If we become aware that we have collected personal data from a child under 13 without verification of parental consent, we will take steps to remove that information from our servers.
              </p>
              <p className="text-gray-400 mt-2">
                Additionally, users must be at least 16 years old to use the app. By using the app, you confirm that you meet the minimum age requirement.
              </p>
            </div>

            <div>
              <h2 className="text-xl font-semibold mb-3">3. Data Processing and Usage</h2>
              <p className="text-gray-400">
                The data holder accepts, states and guarantees that he/she will use the given data in a lawful way which is stated in this user agreement. The data can be processed based on the explicit consent of its owner. Explicit consent is given related to the processing ways stated in the privacy policy.
              </p>
              <p className="text-gray-400 mt-2">
                The data, as stated in the privacy policy, is processed as follows:
              </p>
              <ul className="list-disc list-inside mt-2 text-gray-400 space-y-1">
                <li>CoinInsight processes said private data in accordance with its commercial purposes in a proportionate way</li>
                <li>Registration is anonymous and no personal info like phone numbers is required</li>
                <li>CoinInsight processes data to conduct public opinion surveys, anonymizes responses, and may share results with third parties</li>
                <li>Advertisers are solely responsible for the content of ads shown to users</li>
              </ul>
            </div>

            <div>
              <h2 className="text-xl font-semibold mb-3">4. Processing Without Explicit Consent</h2>
              <p className="text-gray-400">
                In the following cases, CoinInsight may process data without explicit consent:
              </p>
              <ul className="list-disc list-inside mt-2 text-gray-400 space-y-1">
                <li>Legal obligations or law requirements</li>
                <li>Protection of life or physical integrity</li>
                <li>Contract performance</li>
                <li>Publicly available data</li>
                <li>Legitimate interest of the data controller, without infringing rights</li>
              </ul>
            </div>

            <div>
              <h2 className="text-xl font-semibold mb-3">5. User Rights and Responsibilities</h2>
              <p className="text-gray-400">
                Data subjects have the right to:
              </p>
              <ul className="list-disc list-inside mt-2 text-gray-400 space-y-1">
                <li>Access, rectify, or delete their data</li>
                <li>Request information on data use and sharing</li>
                <li>Request compensation for damages due to unlawful processing</li>
              </ul>
              <p className="text-gray-400 mt-2">
                Users agree to use CoinInsight lawfully and take responsibility for their actions on the platform. Users give informed and explicit consent to the data processing methods described.
              </p>
            </div>

            <div>
              <h2 className="text-xl font-semibold mb-3">6. Data Retention and Platform Changes</h2>
              <p className="text-gray-400">
                When data processing is no longer required, it will be deleted or anonymized. CoinInsight may change policies or operations at any time without notifying users. CoinInsight can suspend or terminate user access if terms are violated.
              </p>
            </div>
          </section>

          <div className="mt-12 text-sm text-gray-500">
            <p>Last updated: April 10, 2025</p>
          </div>
        </div>
      </main>
    </>
  );
} 